﻿using System;
using System.Windows.Markup;

namespace Urania.Desktop {
	public class EnumBindingSourceExtension : MarkupExtension {
		private Type _enumType;
		public Type EnumType {
			get { return this._enumType; }
			set {
				if (value != this._enumType) {
					if (null != value) {
						Type enumType = Nullable.GetUnderlyingType(value) ?? value;
						if (!enumType.IsEnum)
							throw new ArgumentException("Type must be for an Enum.");
					}
					this._enumType = value;
				}
			}
		}

		public EnumBindingSourceExtension() { }

		public EnumBindingSourceExtension(Type enumType) {
			this.EnumType = enumType;
		}

		public override object ProvideValue(IServiceProvider serviceProvider) {
			if (null == this._enumType)
				throw new InvalidOperationException("The EnumType must be specified.");

			Type actualEnumType = Nullable.GetUnderlyingType(this._enumType) ?? this._enumType;
			Array enumValues = Enum.GetValues(actualEnumType);

			var filteredEnumValues = Array.CreateInstance(actualEnumType, enumValues.Length - 1);
			// skip first value
			for (int i = 0; i < enumValues.Length; i++) {
				var value = ((Enum) enumValues.GetValue(i)).ToString();
				if (value == "Unknown") continue;
				filteredEnumValues.SetValue(enumValues.GetValue(i), i - 1);
			}
            
			if (actualEnumType == this._enumType)
				return filteredEnumValues;

			Array tempArray = Array.CreateInstance(actualEnumType, filteredEnumValues.Length + 1);
			filteredEnumValues.CopyTo(tempArray, 1);
			return tempArray;
		}
	}
}