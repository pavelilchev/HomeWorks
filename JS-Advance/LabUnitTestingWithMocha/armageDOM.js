function nuke(selector1, selector2) {
    if (selector1 === selector2) return;
    $(selector1).filter(selector2).remove();
}

let expect = require("chai").expect;
let jsdom = require("jsdom-global")();
$ = require('jquery');

describe('nuke(selector1, selector2)', function () {
    beforeEach(function () {
        document.body.innerHTML = `
<div id="target">
    <div class="nested target">
        <p>This is some text</p>
    </div>
    <div class="target">
        <p>Empty div</p>
    </div>
    <div class="inside">
        <span class="nested">Some more text</span>
        <span class="target">Some more text</span>
    </div>
</div>`;
    });
    it('should be in HTML', function () {
        expect(document.body).not.to.be.equal(undefined);
    });

    it('should nuke to be a function', function () {
        expect(typeof nuke).to.be.equal('function');
    });
    it('should do noting if 1 parameters', function () {
        let selector = '#target';
        let len = $(selector).length;
        nuke(selector);
        expect($(selector).length).to.be.equal(len);
    });
    it('should do noting if 1 parameters isnt valid selector', function () {
        let selector1 = '#target';
        let selector2 = 'nested';
        let len = $(selector1).length;
        nuke(selector1, selector2);
        expect($(selector1).length).to.be.equal(len);
    });
    it('should do noting if parameters isnt string', function () {
        let selector = '#target';
        let xhtmlBefore = document.body.innerHTML;
        nuke(selector, 3);
        let xhtmlAfter = document.body.innerHTML;
        expect(xhtmlBefore).to.be.equal(xhtmlAfter);
    });
    it('should do noting if parameters are equals', function () {
        let selector = '#target';
        let xhtmlBefore = document.body.innerHTML;
        nuke(selector, selector);
        let xhtmlAfter = document.body.innerHTML;
        expect(xhtmlBefore).to.be.equal(xhtmlAfter);
    });
    it('should remove nodes whit correct selectors', function () {
        let selector1 = '.target';
        let selector2 = '.nested';
        let elementsBeforeNucke = $(selector1 + selector2);
        nuke(selector1, selector2);
        let elementsAfterNucke = $(selector1 + selector2);
        expect(elementsAfterNucke.length).to.be.equal(0);
    });
    it('should do noting whit correct selectors dosent match node', function () {
        let selector1 = '.target';
        let selector2 = '.inside';
        let elementsTarget = $(selector1).length;
        let elementsInside = $(selector2).length;
        nuke(selector1, selector2);
        let elementsTarget1 = $(selector1).length;
        let elementsInside1 = $(selector2).length;
        expect(elementsTarget).to.be.equal(elementsTarget1);
        expect(elementsInside).to.be.equal(elementsInside1);
    });
});