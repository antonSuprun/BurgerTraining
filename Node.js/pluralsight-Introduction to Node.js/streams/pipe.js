var request = require('request');
var fs =require('fs');
var zlib = require('zlib');

var r2=request('http://pluralsight.com/');
var zlibStream=zlib.createGzip();
var fsStream = fs.createWriteStream('pluralsight.html.gz');

r2.pipe(zlibStream).pipe(fsStream);
