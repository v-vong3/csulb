

const myWorker = new Worker("./worker.js");

myWorker.onmessageerror = function (e) {
    console.log('error from worker', e);
}

myWorker.onerror = function (e) {
    console.log("worker error", e);
}
