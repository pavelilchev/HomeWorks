(function domTraversal(selector) {
    let maxNesting = 0;
    let maxElement = {};
    let parentNode = $(selector);

    function walkTheDOM(node, nesting) {
        let childrens = node.children();

        if (nesting > maxNesting) {
            maxNesting = nesting;
            maxElement = node;
        }

        for (let child of childrens) {
            walkTheDOM($(child), nesting + 1);
        }
    }

    function highlight(element) {
        element.addClass('highlight');
        let parent = element.parent();
        if (element[0].isEqualNode(parentNode[0])) {
            return;
        }

        highlight(parent);
    }


    parentNode.addClass('highlight')
    walkTheDOM(parentNode, 0);
    highlight(maxElement);
})()