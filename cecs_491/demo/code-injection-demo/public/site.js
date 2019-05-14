// NOTE: This file only contains code to make the demo work properly.  

let isSecure = false;

// Used to easily facilitate "Reset" to original code
// Pretend this method doesn't exist 
function originalAdd(leftOperand, rightOperand) {
    let result = leftOperand + rightOperand;

    console.log('Original safe code')

    return result;
}

function addHandler() {
    let leftOp = parseInt(document.getElementById("left").value),
        rightOp = parseInt(document.getElementById("right").value),
        display = document.getElementById("display");

    display.innerText = isSecure ? add(leftOp, rightOp) : a(leftOp, rightOp);
}

function reset() {
    add = originalAdd;
    isSecure = false;
    document.getElementById("display").innerText = '';
}

function toggleSecure() {
    isSecure = !isSecure;
    
    if(isSecure) {
        document.querySelectorAll('textarea').forEach((v) => { v.className = 'secure'});
    } else {
        document.querySelectorAll('textarea').forEach((v) => { v.className = ''});
    }
    
}