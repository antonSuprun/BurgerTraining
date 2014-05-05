var http = require('http');
var count = 0
var server = http.createServer(function(req, res) {
  res.writeHead(200);
  count++;
  var message = 'It was '+count +' calls';
  res.end(message);
  if(count === 10){
    process.exit(1);
  }
});

server.listen(8080);
