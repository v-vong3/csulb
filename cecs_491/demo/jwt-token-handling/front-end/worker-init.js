// Initialize the Web Worker and set error handlers

// Using JavaScript's type coersion and evaluation behaviors 
// to detect presence of feature in browser
if(window.Worker) { 
    const myWorker = new Worker("./worker.js");

    myWorker.onmessageerror = function (e) {
        console.log('error from worker', e);
    }

    myWorker.onerror = function (e) {
        console.log("worker error", e);
    }
} else {
    alert('This browser does not support Web Workers!!');
}


