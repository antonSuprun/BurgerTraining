var http = require('http');
var fs =require('fs');

var options = {
  host: 'www.pluralsight.com',
  port: 80,
  path: '/training',
  method: 'GET'
};

http.get(options, function(response) {
  console.log(response.statusCode);
  var fsStream = fs.createWriteStream('result.txt');
  response.pipe(fsStream);
});
