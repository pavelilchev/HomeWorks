function createCar(commands) {
    let map = new Map();
    let carManager = {
        create: function ([name, ,parent]) {
            parent = parent ? map.get(parent) : null;
            let newObj = Object.create(parent);
            map.set(name, newObj);
            return newObj;
        },
        set: function ([name, key, value]) {
            let obj = map.get(name);
            obj[key] = value;
        },
        print: function (name) {
            let obj = map.get(name[0]);

            let result = '';
            let first = true;
            for (let prop in obj) {
                if(!first)
                    result += ', ';

                first = false;
                result += prop + ':' + obj[prop]
            }

            console.log(result);
            // console.log(
            //     Object.keys(obj).map((key)=>`${key}:${obj[key]}`).join(', '));
        }
    };

    for (let command of commands) {
        let commandParameters = command.split(' ');
        let action = commandParameters.shift();
        carManager[action](commandParameters);
    }
}

console.log(createCar(['create c1',
    'create c2 inherit c1',
    'set c1 color red',
    'set c2 model new',
    'print c1',
    'print c2']))