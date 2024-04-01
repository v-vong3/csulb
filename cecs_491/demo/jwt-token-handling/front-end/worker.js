
// Code here is running on a separate background thread from the 
// current Window

// NOTE: 
// Web Workers are not meant o manipulate the DOM directly. 
// They are for executing non-blocking (UI) code such as
// network requests  


const workerToken = { value: null };

onmessage = function(e) {
    console.log('on message', e);

    if(workerToken.value == null) {
        workerToken.value = e.data;

        // Data is always passed as a copy/duplicate
        // between worker thread and main thread.
        // structuredClone() is used during message posts, thus 
        // the supported data types is limited, which makes 
        // designing on message format a critical design decision.
        postMessage(JSON.stringify(workerToken));

        // For passing large data, use "Transferable objects" version
        // > postMessage(message, [TransferableObj])

        return;
    }

    postMessage('Already saved');
}

// Demonstrates availability of Browser APIs in the
// WorkerGlobalScope (global executing context of worker).
// Some API availability depends if the worker is 
// a dedicated or shared worker
console.log('window available?', !!window);
console.log('self available?', !!self);
console.log('DOM available?', !!document);
console.log('cookies available?', !!document.cookie);
console.log('cookieStore available?', !!cookieStore);
console.log('sessionStorage available?', !!sessionStorage);
console.log('localStorage available?', !!localStorage);
console.log('indexedDB available?', !!indexedDB);
console.log('fetch available?', !!fetch);
console.log('XMLHttpRequest available?', !!XMLHttpRequest);
console.log('JSON available?', !!JSON);
console.log('setTimeout available?', !!setTimeout);
console.log('setInterval available?', !!setInterval);
console.log('WebSockets available?', !!WebSocket);
console.log('Crpto available?', !!Crypto.subtle);

// Avoid using eval() as it is a major security vulnerability
console.log('eval available?', !!eval);


