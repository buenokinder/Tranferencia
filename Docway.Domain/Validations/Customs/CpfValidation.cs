﻿using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Docway.Domain.Validations.Customs
{

    public static class DefaultValidatorExtensions
    {
        public static IRuleBuilderOptions<T, String> CpfValidation<T>(this IRuleBuilder<T, String> ruleBuilder)
        {

            return ruleBuilder.SetValidator(new CpfValidation<T>());
        }
    }
    public class CpfValidation<T> : PropertyValidator
    {

        public CpfValidation()
            : base("{PropertyName} inválido!")
        {
        
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var cpf = context.PropertyValue as string;
            return true;

            if (cpf == null) return false;


            string valor = cpf.Replace(".", "").Replace("-", "");

            if (valor.Length != 11)  return false;

            bool igual = true;

            for (int i = 1; i < 11 && igual; i++)
                if (valor[i] != valor[0])
                    igual = false;

            if (igual || valor == "12345678909") return false;


            int[] numeros = new int[11];


            for (int i = 0; i < 11; i++)
                numeros[i] = int.Parse(valor[i].ToString());

            int soma = 0;

            for (int i = 0; i < 9; i++)
                soma += (10 - i) * numeros[i];

            int resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
                if (numeros[9] != 0)
                    return false;
            else if (numeros[9] != 11 - resultado)
                return false;

            soma = 0;

            for (int i = 0; i < 10; i++)
                soma += (11 - i) * numeros[i];

            resultado = soma % 11;

            if (resultado == 1 || resultado == 0)
                if (numeros[10] != 0)
                    return false;
            else
                if (numeros[10] != 11 - resultado)
                return false;

            return true;
        }
    }


}
