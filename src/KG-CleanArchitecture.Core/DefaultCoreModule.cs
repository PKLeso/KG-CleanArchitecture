using Autofac;
using KG_CleanArchitecture.Core.Interfaces;
using KG_CleanArchitecture.Core.Services;

namespace KG_CleanArchitecture.Core;

public class DefaultCoreModule : Module
{
  protected override void Load(ContainerBuilder builder)
  {
    builder.RegisterType<ToDoItemSearchService>()
        .As<IToDoItemSearchService>().InstancePerLifetimeScope();
  }
}
