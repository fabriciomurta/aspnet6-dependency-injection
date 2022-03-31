using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace pjstub
{
  public static class StubExtensions
  {
    internal static IApplicationBuilder UseStub(this IApplicationBuilder builder)
    {
      var runtimeCtx = builder.ApplicationServices.GetService<IStubRuntimeCtx>();
      if (runtimeCtx is null)
      {
          throw new Exception("Stub services are not configured.");
      }

      var resourcesConfigured = runtimeCtx.ResourcesConfigured == true;
      if (!resourcesConfigured)
      {
          builder.UseStubResources();
      }

      return builder;
    }

    internal static void AddStub(this IServiceCollection services)
    {
      services.AddSingleton<IStubRuntimeCtx, StubRuntimeCtx>();
      services.TryAddEnumerable(
        ServiceDescriptor.Singleton<IActionInvokerProvider, MyActionInvokerProvider>()
      );
    }

    public static IApplicationBuilder UseStubResources(this IApplicationBuilder builder)
    {
      if (builder is null)
      {
        throw new ArgumentNullException(nameof(builder));
      }

      var runtimeCtx = builder.ApplicationServices.GetService<IStubRuntimeCtx>();
      if (runtimeCtx is null)
      {
          throw new Exception("Stub services are not configured.");
      }

      runtimeCtx.ResourcesConfigured = true;

      return builder;
    }
  }
}