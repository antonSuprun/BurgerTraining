var events = require('events');
var util = require('util');

// The Thing That Emits Event
Eventer = function(c){
  var e = this;
  var maxEvent=c;
  process.nextTick(function(){
    var count = 0;
    e.emit('start');
    var t = setInterval(function(){
      e.emit('data',++count);
      if(count === maxEvent){
        e.emit('end', count);
        clearInterval(t);
      }
    }, 10);
  });
 
 };
util.inherits(Eventer, events.EventEmitter);
module.exports = Eventer;
