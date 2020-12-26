``` 
docker pull mongo

backing-services
# To run needed services
docker-compose up -d

Mongo is running 27017

# Create repo
dotnet new webapi -o PhotoRepo


#MongoDriver install
dotnet add package MongoDB.Driver --version 2.11.5


# Set connection string
"ConnectionStrings": {
    "Mongo": ""
}



# Startup.cs

app.UseHttpsRedirection();

    app.UseStaticFiles(
        new StaticFileOptions{
            FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "public")),
                RequestPath = "/public"
        }
    );
```


# Tasks

- [ ] Create Model Mongo
- [ ] Create a Repo for Photo
- [ ] Crud for PhotoCollection
