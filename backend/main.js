const {MongoClient} = require("mongodb");
const Express = require("express");
const BodyParser = require('body-parser');

const server = Express();
const client = new MongoClient("mongodb+srv://seyit:mongomap123@turharita.nu7eczs.mongodb.net/test");

server.use(BodyParser.json());
server.use(BodyParser.urlencoded({extended: true}));

var collection;

server.get("/numberPlate", async(request,response,next)=>{
    try {
        //let result = await collection.find({}).toArray();
        let result = await collection.toArray();
        response.send(result);
    } catch (e) {
        response.status(500).send({message: e.message});
    }
});
server.get("/numberPlate/:cityName", async(request,response,next)=>{
    try {
        let collection2 = client.db("TurkeyMap").collection("numberPlate").aggregate([
            {
                $match: {cityName: request.params.cityName}
            },
            {
                $lookup:{
                    from: "populationValue",
                    localField: "cityName",
                    foreignField: "cityName",
                    as: "pop-val"
                }
            },
            { $unwind: "$pop-val"},
            {
                $lookup:{
                    from: "heatValue",
                    localField: "cityName",
                    foreignField: "cityName",
                    as: "heat-val"
                }
            },
            { $unwind: "$heat-val"},
            {
                $project:{
                    _id : 1,
                    cityName : 1,
                    plateNumber : 1,
                    heatValue : "$heat-val.heatValue",
                    populationValue : "$pop-val.populationValue",
                }
            }

        ]);
        collection2;
        //let result = await collection.findOne({"heatValue": request.params.heatValue});
        let result = await collection2.toArray();
        response.send(result);
    } catch (e) {
        response.status(500).send({message: e.message});
    }
});
server.listen("3000", async()=>{

    try {
        await client.connect();
        collection = client.db("TurkeyMap").collection("numberPlate").aggregate([
            {
                $lookup:{
                    from: "populationValue",
                    localField: "cityName",
                    foreignField: "cityName",
                    as: "pop-val"
                }
            },
            { $unwind: "$pop-val"},
            {
                $lookup:{
                    from: "heatValue",
                    localField: "cityName",
                    foreignField: "cityName",
                    as: "heat-val"
                }
            },
            { $unwind: "$heat-val"},

            {
                $project:{
                    _id : 1,
                    cityName : 1,
                    plateNumber : 1,
                    heatValue : "$heat-val.heatValue",
                    populationValue : "$pop-val.populationValue",
                }
            }
        ]);
        console.log("Listening at :3000");
    } catch (e) {
        console.log(e);
    }

});