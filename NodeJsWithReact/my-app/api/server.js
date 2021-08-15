const express = require("express")
const app = express()
const soapRequest = require('easy-soap-request');
const { transform, prettyPrint } = require('camaro');

var convert = require('xml-js');


var xmldom = require('xmldom');
var xpath = require('xpath');

var parser = new xmldom.DOMParser();
var serializer = new xmldom.XMLSerializer();

const fs = require('fs');



const xml2js = require('xml2js');
var builder = new xml2js.Builder();

const util = require('util');



const cors = require("cors");
const { parse } = require("path");
app.use(cors())

const url = 'https://localhost:44387/EmployeeListerService.asmx';
const sampleHeaders = {
    'user-agent': 'sampleTest',
    'Content-Type': 'text/xml',
};
const xml = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><select_all_employees xmlns="http://tempuri.org/" /></soap:Body></soap:Envelope>';
const xml2 = '<?xml version="1.0" encoding="utf-8"?><soap:Envelope xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/"><soap:Body><select_employeesWithPreFiltered xmlns="http://tempuri.org/" /></soap:Body></soap:Envelope>';


app.get("/", function (req, res) {

    process.env["NODE_TLS_REJECT_UNAUTHORIZED"] = 0;

    (async () => {
        const { response } = await soapRequest({ url: url, headers: sampleHeaders, xml: xml2, timeout: 1000 }); // Optional timeout parameter(milliseconds)
        const { headers, body, statusCode } = response;
        //console.log(headers);
        // console.log(body);

        var soapBodyXML = body;

        var body2 = soapBodyXML.replace('<soap:Envelope xmlns:soap="http://schemas.xmlsoap.org/soap/envelope/" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema"><soap:Body><select_employeesWithPreFilteredResponse xmlns="http://tempuri.org/"><select_employeesWithPreFilteredResult>', "<Employees>")
            .replace('</select_employeesWithPreFilteredResult></select_employeesWithPreFilteredResponse></soap:Body></soap:Envelope>', "</Employees>")


        xml2js.parseString(body2, (err, result) => {
            if (err) {
                throw err;
            }

            const json = JSON.stringify(result, null, 1);


            console.log(json);

            res.send(json)

        });

        res.send(json)
    })();


})


app.listen(3000, () => {
    console.log("app listening on port 3000")
})

