function argumentInfo() {
    let summary = {};

    for (let i = 0;i < arguments.length; i++) {
        let obj = arguments[i];
        let type = typeof(obj);
        console.log(type + ": " + obj);
        if(!summary[type]){
            summary[type] = 1;
        } else {
            summary[type]++;
        }
    }

    let sortedSummary = Object.keys(summary).sort(function (a, b) {
        return summary[b] - summary[a];
    });

    for(let key of sortedSummary){
        console.log(key + ' = ' + summary[key]);
    }
}

argumentInfo({ name: 'bob'}, 3.333, 9.999);