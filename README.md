# Photo Repo

Simple Photo Repo to save images under the folder `public`

and save paths on Mongo database

## Requirements

* Dotnet Core 3.1
* Mongo database
* Docker (optional)

## Install

1. Run Mongo database

You can run the database locally, it is optional if you want to use docker, the project contains a docker-compose to run it

``` 
    docker-compose -f backing-services/docker-compose.yml  up -d
```

2. Set the Mongo connection string

Set the connection string on `appsettings.json`

``` 
    ...
    "ConnectionStrings": {
        "Mongo": "mongodb://root:example@localhost:27017"
    }
```

3. Install dependencies

``` 
    dotnet restore
    dotnet run
```

4. Endpoints

* *Save image*

``` 
    curl --location --request POST 'https://localhost:5001/photos' \
    --form 'image=@"/path/awesome_image.png"'

    ### Returns the new photo Object saved on Mongo
    {
        "id": "5fe7ba0a9527eb18dd6979a5",
        "object": {
            "timestamp": 1609021962,
            "machine": 9775083,
            "pid": 6365,
            "increment": 6912421,
            "creationTime": "2020-12-26T22:32:42Z"
        },
        "originalname": "visual-studio-code-2019.png",
        "size": 9280,
        "filePath": "/home/drec/code/regularBlog/PhotoRepo/public/8375c9ca-a0ec-48c9-8028-009db8aa6919.png",
        "urlPath": "public/8375c9ca-a0ec-48c9-8028-009db8aa6919.png"
    }
    
```

* *GetAll*

``` 
    curl -k https://localhost:5001/photos

    ####
    {
        "count": 2,
        "photos": [
            {
                "id": "5fe7a1258d785f9cb20f84d9",
                "object": {
                    "timestamp": 1609015589,
                    "machine": 9271391,
                    "pid": -25422,
                    "increment": 1017049,
                    "creationTime": "2020-12-26T20:46:29Z"
                },
                "originalname": "k.png",
                "size": 19623,
                "filePath": "/home/drec/code/regularBlog/PhotoRepo/public/ed29da66-bc14-4747-a8a6-137c52c85d38.png",
                "urlPath": "public/ed29da66-bc14-4747-a8a6-137c52c85d38.png"
            },
            {
                "id": "5fe7a1c46d39b9e5ba19e392",
                "object": {
                    "timestamp": 1609015748,
                    "machine": 7158201,
                    "pid": -6726,
                    "increment": 1696658,
                    "creationTime": "2020-12-26T20:49:08Z"
                },
                "originalname": "visual-studio-code-2019.png",
                "size": 9280,
                "filePath": "/home/drec/code/regularBlog/PhotoRepo/public/fd76ec88-2deb-4fd4-a154-b4afcd72fc10.png",
                "urlPath": "public/fd76ec88-2deb-4fd4-a154-b4afcd72fc10.png"
            }
        ]
    }
```

* *GetById*

``` 
    curl -k https://localhost:5001/photos/{{id}}
    {
        "id": "5fe7ba0a9527eb18dd6979a5",
        "object": {
            "timestamp": 1609021962,
            "machine": 9775083,
            "pid": 6365,
            "increment": 6912421,
            "creationTime": "2020-12-26T22:32:42Z"
        },
        "originalname": "visual-studio-code-2019.png",
        "size": 9280,
        "filePath": "/home/drec/code/regularBlog/PhotoRepo/public/8375c9ca-a0ec-48c9-8028-009db8aa6919.png",
        "urlPath": "public/8375c9ca-a0ec-48c9-8028-009db8aa6919.png"
    }
```

* *Get the photo*

You need to use the UrlPath that is returned on the get/save `"urlPath": "public/8375c9ca-a0ec-48c9-8028-009db8aa6919.png"`

Then build the url `https://localhost:5001/{urlPath}`

Example: `https://localhost:5001/public/ed29da66-bc14-4747-a8a6-137c52c85d38.png`

And you will get the image

![Image uploaded](_ReadmeFiles/screenshot_demo.png)

## Credits

Based on Fazt's app with Typescript, Nodejs & MongoDB
* [Fazt Typescript, Nodejs & MongoDB](https://www.youtube.com/watch?v=OMBwyCNmoPY)