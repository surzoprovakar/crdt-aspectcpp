const fs = require('fs');
const Parser = require('acorn')
const esprima = require('esprima');
const escodegen = require('escodegen');


function traverseAST(node, callback) {
    callback(node);

    if (node.type === 'Program') {
        for (const childNode of node.body) {
            traverseAST(childNode, callback);
        }
    } else {
        for (const key in node) {
            if (node.hasOwnProperty(key)) {
                const childNode = node[key];
                if (typeof childNode === 'object' && childNode !== null && key !== 'parent') {
                    traverseAST(childNode, callback);
                }
            }
        }
    }
}

// For controller class
//const ast1 = Parser.parse(fs.readFileSync('../conclave-js/lib/controller.js').toString())
const ast1 = esprima.parseModule(fs.readFileSync('../lib/controller.js').toString())
console.log(ast1)

const targetMethodName = 'makeOwnName';

traverseAST(ast1, (node) => {

    // Modify function
    if (node.type === 'MethodDefinition' && node.key.name === targetMethodName) {
      // Step 3: Edit the method name in the AST
      //node.key.name = 'newMethodName';
      const newStatement1 = esprima.parseScript('console.log(name + " is created as peer")');
      //const newStatement2 = esprima.parseScript('console.log("Line 2 added!");');
      //node.value.body.body.unshift(newStatement1); // Add new statement to the beginning of the method body
      node.value.body.body.push(newStatement1);
     // node.value.body.body.push(newStatement2); // Add new statement to the end of the method body
    }
  
    // Get constructor args
    // if (node.type === 'MethodDefinition' && node.kind === 'constructor') {
    //   // Step 3: Retrieve the parameters of the constructor
    //   const constructorParams = node.value.params.map(param => param.name);
    //   console.log(`Constructor parameters: ${constructorParams.join(', ')}`);
    // }
  
    // if (node.type === 'CallExpression' && node.callee.property && node.callee.property.name === targetMethodName) {
    //   console.log("comes here")
    //   // Step 3: Retrieve the arguments of the function call
    //   const arg1Value = node.arguments[0].value;
    //   //const arg2Value = node.arguments[1].value;
    //   console.log(`Argument 1 value: ${arg1Value}`);
    //   //console.log(`Argument 2 value: ${arg2Value}`);
    // }
  
  });

// Step 4: Generate JavaScript code from the updated AST
const updatedCode = escodegen.generate(ast1);

console.log("updatedCode");
console.log(updatedCode);

fs.writeFileSync('../lib/controller.js', updatedCode)


// For crdt class
const ast2 = esprima.parseModule(fs.readFileSync('../lib/crdt.js').toString())
console.log(ast2)


const targetMethodNameInsert = 'handleLocalInsert'

const targetMethodNameSingleDel = 'deleteSingleLine'

const targetMethodNameMultieDel = 'deleteMultipleLines'

traverseAST(ast2, (node) => {

    // Modify function
    if (node.type === 'MethodDefinition' && node.key.name === targetMethodNameInsert) {
      // Step 3: Edit the method name in the AST
      //node.key.name = 'newMethodName';
      const newStatement1 = esprima.parseScript('console.log("crdt local inserted char " + char.value)');
      //const newStatement2 = esprima.parseScript('console.log("Line 2 added!");');
      //node.value.body.body.unshift(newStatement1); // Add new statement to the beginning of the method body
      node.value.body.body.push(newStatement1);
     // node.value.body.body.push(newStatement2); // Add new statement to the end of the method body
    }

    if (node.type === 'MethodDefinition' && node.key.name === targetMethodNameSingleDel) {
        // Step 3: Add code before the last line of the function
        const newStatement = esprima.parseScript('console.log("crdt local deleted single-line char: " + chars[0].value)');
        node.value.body.body.splice(node.value.body.body.length - 1, 0, newStatement);
    }

    if (node.type === 'MethodDefinition' && node.key.name === targetMethodNameMultieDel) {
        // Step 3: Add code before the last line of the function
        const newStatement = esprima.parseScript('console.log("crdt local deleted multiple-lines char [n]")');
        node.value.body.body.splice(node.value.body.body.length - 1, 0, newStatement);
    }
});

const updatedCode2 = escodegen.generate(ast2);

console.log("updatedCode2");
console.log(updatedCode2);

fs.writeFileSync('../lib/crdt.js', updatedCode2)