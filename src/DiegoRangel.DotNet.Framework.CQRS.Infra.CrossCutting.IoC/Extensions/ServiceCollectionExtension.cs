﻿using System;
using System.Collections.Generic;
using System.Linq;
using DiegoRangel.DotNet.Framework.CQRS.Domain.Core.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace DiegoRangel.DotNet.Framework.CQRS.Infra.CrossCutting.IoC.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection RegisterWhoImplements(this IServiceCollection service, Type interfaceType, string projectName)
        {
            var types = GetAssembliesFrom(projectName);

            var interfaces = types
                .Where(x => !x.IsClass && x.GetInterfaces().Contains(interfaceType)).Select(x => x).ToList();

            foreach (var i in interfaces)
            {
                var classe = types.Where(x =>
                    x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(interfaceType) &&
                    x.GetInterfaces().Contains(i)).Select(x => x).FirstOrDefault();

                if (classe == null)
                    continue;

                service.AddScoped(i, classe);
            }

            return service;
        }

        public static void RegisterStateMachines(this IServiceCollection service, string projectName)
        {
            var types = GetAssembliesFrom(projectName);
            var stateMachines = types
                .Where(x =>
                    x.IsClass && !x.IsAbstract && x.GetInterfaces().Contains(typeof(IStateMachine))
                ).Select(x => x).ToList();

            foreach (var x in stateMachines)
            {
                service.AddScoped(x);
            }
        }

        private static IList<Type> GetAssembliesFrom(string projectName)
        {
            return AppDomain.CurrentDomain.Load(projectName).GetTypes().ToList();
        }
    }
}