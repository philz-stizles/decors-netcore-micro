using Elasticsearch.Net;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cart.API.Extensions
{
    public static class ElasticSearchServiceExtension
    {
        public static IServiceCollection AddElasticSearchServices(this IServiceCollection services, IConfiguration configuration)
        {

            var elasticUris = configuration.GetSection("ElasticSearchSettings:Uri").Get<string[]>();

            if (elasticUris.Length > 0)
            {
                ConnectionSettings settings;
                if (configuration.GetSection("ElasticSearchSettings:Cluster").Get<bool>() == false)
                {
                   if(string.IsNullOrEmpty(elasticUris[0]))
                    {
                        return services;
                    }

                    var pool = new SingleNodeConnectionPool(new Uri(elasticUris[0]));
                    settings = new ConnectionSettings(pool)
                        .DefaultIndex("products");
                }
                else
                {
                    var uris = new List<Uri>();
                    foreach (var uri in elasticUris)
                    {
                        if(!string.IsNullOrEmpty(uri))
                        {
                            uris.Add(new Uri(uri));
                        }
                    }

                    if(uris.Count() <= 0)
                    {
                        return services;
                    }

                    var connectionPool = new SniffingConnectionPool(uris);
                    settings = new ConnectionSettings(connectionPool)
                        .DefaultIndex("products");
                }

                var client = new ElasticClient(settings);
                services.AddSingleton(client);
            }

            return services;
        
        }
    }
}
