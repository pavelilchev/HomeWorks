const storage = require('./storage')

try{
    storage.put(1, 'a')
}
catch(err){
    console.log(err)
}

try{
  storage.put('first', 1)
}
catch(err){
    console.log(err)
}

try{
   storage.put('first', 2)
}
catch(err){
    console.log(err)
}

try{
   storage.get(1)
}
catch(err){
    console.log(err)
}

try{
   storage.get('firs')
}
catch(err){
    console.log(err)
}

try{
  var value = storage.get('first')
  console.log(value)
}
catch(err){
    console.log(err)
}

storage.update('first', 'first')
let first = storage.get('first')
console.log(first)
storage.delete('first')

try{
storage.get('first')
}
catch(err){
    console.log(err)
}

storage.put('a', 1)
storage.clear()
try{
    let a = storage.get('a')
    console.log(a)
}
catch(err){
    console.log(err)
}

storage.put('first', 1)
storage.put('second', true)

storage.save()
    .then(() => {
        storage.clear()
        storage.load()
        .then(() => {
            console.log(storage.get('second'))
        })
    })

