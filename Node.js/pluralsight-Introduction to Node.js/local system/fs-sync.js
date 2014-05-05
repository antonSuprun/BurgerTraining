fs = require('fs');

if(fs.existsSync('temp')){
  console.log('Directory exist, removing...');
  if(fs.existsSync('temp/new.txt')){
    fs.unlinkSync('temp/new.txt');
  }
  fs.rmdirSync('temp');
}

fs.mkdirSync('temp');
if(fs.existsSync('temp')){
  process.chdir('temp');
  fs.writeFileSync('test.txt', 'This is some text for test file.');
  fs.renameSync('test.txt', 'new.txt');
  console.log('File size:' + fs.statSync('new.txt').size + ' bytes');
  console.log('File contents: ' + fs.readFileSync('new.txt').toString());
}
