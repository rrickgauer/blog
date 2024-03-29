﻿using BlogPilot;
using BlogPilot.Services.Injection;
using BlogPilot.Services.Service.Interface;
using Microsoft.Extensions.DependencyInjection;


bool isProduction = true;

#if DEBUG
isProduction = false;
#endif

ServiceCollection services = new();
var injector = new ServicesInjector(services, isProduction);
injector.InjectDependencies();

ServiceProvider serviceProvider = services.BuildServiceProvider();

TestingMethods.TestEnumDescription();

