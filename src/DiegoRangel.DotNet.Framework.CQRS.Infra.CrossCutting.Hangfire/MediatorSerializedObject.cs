﻿using System.Linq;

namespace DiegoRangel.DotNet.Framework.CQRS.Infra.CrossCutting.Hangfire
{
    public class MediatorSerializedObject
    {
        public string FullTypeName { get; }

        public string Data { get; }

        public string AdditionalDescription { get; }

        public MediatorSerializedObject(string fullTypeName, string data, string additionalDescription)
        {
            FullTypeName = fullTypeName;
            Data = data;
            AdditionalDescription = additionalDescription;
        }

        /// <summary>
        /// Override for Hangfire dashboard display.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var commandName = FullTypeName.Split('.').Last();
            return $"{commandName} {AdditionalDescription}";
        }
    }
}