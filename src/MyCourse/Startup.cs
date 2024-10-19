﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;

namespace MyCourse
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Aggiungo i servizi richiesti come per es. un componente chiamato ControllerFactory che
            //ha lo scopo di costruire un controller, oppure il ControllerActionInvoker che si occupa di
            //trovare ed invocare le action 
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //if (env.IsDevelopment())
            if (env.IsEnvironment("Development"))
            {
                app.UseDeveloperExceptionPage();
            }

            //Middleware dei file statici (Jpeg, svg, css, ecc.)
            app.UseStaticFiles();
            
            //Aggiungo il Middleware di routing la cui responsabilità è quella di andare a mappare
            //percorsi della richiesta dell'utente a Controller in modo che le loro Action possano
            //essere invocate per produrre una risposta per l'utente
            //app.UseMvcWithDefaultRoute();

            //UseMvc accetta come parametro un'action di IRouteBuilder, cioè una funzione che ha come 
            //unico parametro un'oggetto di tipo IRouteBuilder
            
            app.UseMvc(RouteBuilder =>
            {
                //all'interno del corpo della funzione sto definendo una route; ogni route è identificata
                //da un nome che può essere arbitrario ed un template di 3 frammenti.
                //supponiamo che l'utente ci invii questa richiesta: /courses/detail/5
                //Grazie a questo template che abbiamo definito, il middleware di routing è in grado 
                //di capire che deve andarsi a costruire un controller il cui nome sarà courses
                //(cioè il nostro CoursesController), poi invocare l'action Detail ed eventualmente
                //passargli questo 5 che si chiamerà "id"
                RouteBuilder.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
                //"Home" sarà il nome del controller predefinito, cioè quello che viene usato se dovesse
                //mancare il frammento controller, stessa logica per l'action. Il frammento id può essere
                //anche opzionale
            });
        }
    }
}