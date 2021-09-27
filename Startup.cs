using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CatelogVS.Repositories;
using CatelogVS.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

namespace CatelogVS
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));//ID
            BsonSerializer.RegisterSerializer(new DateTimeOffsetSerializer(BsonType.String));//DateTime
            services.AddSingleton<IMongoClient>(ServiceProvider =>
            {
                var setting = Configuration.GetSection(nameof(MongoDbSetting)).Get<MongoDbSetting>();
                return new MongoClient(setting.connectionString);
            });
            
            services.AddSingleton<InterfaceRepository,MongoDbItemsRepository>();//Register Data จาก 2 Class
            services.AddControllers(options => 
            {
                options.SuppressAsyncSuffixInActionNames = false;
                //เมื่อเราได้เปลี่ยนมาใช้ method async ทุกครั้งเวลา กด run dotnet จะลบ async ที่ต่อท้ายชื่อ method ออก และจะทำให้ไม่สารารถรับหรือส่งข้อมูลได้ คือจะไม่มีเส้นทาง
                //การที่เราประกาศแบบนี้ SuppressAsyncSuffixInActionNames = false จะทำให้ dotnet ไม่สามารถ ลบ async ที่ต่อท้ายชื่อ method ออกได้ และเราจะรับส่งข้อมูลได้ได้ปกติ คือมีเส้นทาง
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CatelogVS", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CatelogVS v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
