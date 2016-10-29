let result = (function (command) {
    let elements = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let recieps = {
        apple: {carbohydrate: 1, flavour: 2},
        coke: {carbohydrate: 10, flavour: 20},
        burger: {carbohydrate: 5, fat: 7, flavour: 3},
        omlet: {protein: 5, fat: 1, flavour: 1},
        cheverme: {protein: 10, carbohydrate: 10, fat: 10, flavour: 10}
    };

    function restock(commandArgs) {
        let [element, quantity] = commandArgs;
        elements[element] += Number(quantity);
        return 'Success';
    }

    function prepare(commandArgs) {
        let [recipe, quantity] = commandArgs;
        quantity = Number(quantity);
        for (let element of Object.keys(recieps[recipe])) {
            if (elements[element] < recieps[recipe][element]) {
                return `Error: not enough ${element} in stock`
            }
        }

        for (let element of Object.keys(recieps[recipe])) {
            elements[element] -= recieps[recipe][element] * quantity;
        }

        return 'Success';
    }

    function report() {
        return `protein=${elements.protein} carbohydrate=${elements.carbohydrate} fat=${elements.fat} flavour=${elements.flavour}`
    }

    let commandExecuter = {
        restock: restock,
        prepare: prepare,
        report: report
    };

    return function (commandLine) {
        commandLine = commandLine.split(' ');
        let command = commandLine.shift();
        return commandExecuter[command](commandLine);
    }
})();


var expectationPairs = [
    ['restock protein 10', 'Success'],
    ['restock carbohydrate 10', 'Success'],
    ['restock fat 10', 'Success'],
    ['prepare cheverme 1', 'Success'],
    ['prepare burger 1', 'Success'],
    ['report', 'protein=0 carbohydrate=4 fat=3 flavour=5']
];

for (let i = 0; i < expectationPairs.length; i++) {
    let expectation = expectationPairs[i];
    console.log(result(expectation[0]))
}
