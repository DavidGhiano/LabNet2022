using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Lab.TP8.Api.Models.Validation
{
    public class NoNumberSymbolAttribute : ValidationAttribute
    {
        public NoNumberSymbolAttribute() : base("Solo ingresar letras, no números y símbolos.") { }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                string palabra = (string)value;
                palabra = palabra.ToLower();
                for (int i = 0; i < palabra.Length; i++)
                {
                    if (palabra[i] < 'a' || palabra[i] > 'z')
                    {
                        if (palabra[i] != 'á' && palabra[i] != 'é' && palabra[i] != 'í' && palabra[i] != 'ó' && palabra[i] != 'ú')
                        {
                            var mensajeError = FormatErrorMessage(validationContext.DisplayName);
                            return new ValidationResult(mensajeError);
                        }
                    }
                }
            }
            return ValidationResult.Success;
        }
    }
}