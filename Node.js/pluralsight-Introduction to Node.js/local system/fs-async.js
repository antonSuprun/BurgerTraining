fs = require('fs');

if(fs.existsSync('temp')){
  console.log('Directory exist, removing...');
  if(fs.existsSync('temp/new.txt')){
    fs.unlinkSync('temp/new.txt');
  }
  fs.rmdirSync('temp');
}

function workWithFolder(exist){
  if(exist){
      process.chdir('temp');
      fs.writeFile('test.txt', 'This is some text for test file.', renameFile(err) {
      });
    }
}

function renameFile(err){
  fs.rename('test.txt', 'new.txt', workWithFile(err));
}

function workWithFile(err){
  fs.stat('new.txt', function(err, status){
    console.log('File size:' + status.size + ' bytes');          
  });
  fs.readFile('new.txt', function(err,data){
    console.log('File contents: ' + data.toString());          
  });
}

fs.mkdir('temp', function (err) {
  fs.exist('temp', workWithFolder(exist));
});
