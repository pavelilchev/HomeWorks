let sum = require('../sumOfNumbers').sum;
let expect = require("chai").expect;

describe("sum(arr)", function() {
    it("shoud sum 1+2 = 3", function() {
        expect(sum([1, 2])).to.be.equal(3);
    });

    it("shoud sum empty array = 0", function() {
        expect(sum([])).to.be.equal(0);
    });

    it("shoud sum 1 = 1", function() {
        expect(sum([1])).to.be.equal(1);
    });

    it("shoud sum 1.5 + 2.5 + -1 = 3", function() {
        expect(sum([1.5,2.5,-1])).to.be.equal(3);
    });

    it("shoud sum invalid data = NAN", function() {
        expect(sum(['az'])).to.be.NaN;
    });
});