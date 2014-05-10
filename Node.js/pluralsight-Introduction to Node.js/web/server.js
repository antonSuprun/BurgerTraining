var http = require('http');
var fs = require('fs');

var server = http.createServer(function(req, res) {
  res.writeHead(200,{'Content-Type': 'text/plain'});
  if(req.url === '/file.txt'){
    fs.createReadStream(__dirname+'/file.txt').pipe(res);  
  }
  else{
    console.log(req.url);
    res.end('Hello world');
  }
  
});

server.listen(8080);
