var Eventer = require('./resource');
// The thing that drives the two.
var eventer = new Eventer(7);

eventer.on('start', function() {
  console.log("I've started.");
});

eventer.on('data', function(d) {
  console.log("I recived data -> "+ d);
});

eventer.on('end', function(t) {
  console.log("I am done, with "+ t +" data events.");
});
