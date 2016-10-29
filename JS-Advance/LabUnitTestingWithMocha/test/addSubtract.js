function createCalculator() {
    let value = 0;
    return {
        add: function(num) { value += Number(num); },
        subtract: function(num) { value -= Number(num); },
        get: function() { return value; }
    }
}
let expect = require("chai").expect;

describe("createCalculator()", function() {
    let calc;
    beforeEach(function() {
        calc = createCalculator();
    });
    it("should return proper object", function() {
        expect(calc).to.have.ownProperty('add');
        expect(calc.add).to.be.instanceof(Function);
        expect(calc).to.have.ownProperty('subtract');
        expect(calc.subtract).to.be.instanceof(Function);
        expect(calc).to.have.ownProperty('get');
        expect(calc.get).to.be.instanceof(Function);
    });
    it("should return 0 after create", function() {
        value = calc.get();
        expect(value).to.be.equal(0);
    });
    it("should return 0 after create", function() {
        value = calc.value;
        expect(value).to.be.equal(undefined);
    });
    it("should return 5 after {add 5}", function() {
        calc.add(5); let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return 5 after {add '5'}", function() {
        calc.add('5'); let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return -5 after {add -5}", function() {
        calc.add(-5); let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return -5 after {add -5}", function() {
        calc.subtract('5'); let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return 0 after {add 0}", function() {
        calc.add(0); let value = calc.get();
        expect(value).to.be.equal(0);
    });
    it("should return 5 after {add 3; add 2}", function() {
        calc.add(3); calc.add(2); let value = calc.get();
        expect(value).to.be.equal(5);
    });
    it("should return 5 after {add 3; add 2}", function() {
        calc.subtract(3); calc.subtract(2); let value = calc.get();
        expect(value).to.be.equal(-5);
    });
    it("should return 5 after {add 3; add 2}", function() {
        calc.add(5.3); calc.subtract(1.1); let value = calc.get();
        expect(value).to.be.equal(5.3-1.1);
    });
    it("should return 5 after {add 3; add 2}", function() {
        calc.add(10); calc.subtract(7);calc.add(-2);
        calc.subtract(-1);let value = calc.get();
        expect(value).to.be.equal(2);
    });
    it("should return 0 after create", function() {
        calc.add('hello')
        value = calc.get();
        expect(value).to.be.NaN;
    });
    it("should return 0 after create", function() {
        calc.subtract('hello')
        value = calc.get();
        expect(value).to.be.NaN;
    });
});