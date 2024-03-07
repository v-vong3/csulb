
const workerToken = { value: null };

onmessage = function(e) {
    console.log('on message', e);

    if(workerToken.value == null) {
        workerToken.value = e.data;

        postMessage(JSON.stringify(workerToken));

        return;
    }

    postMessage('Already saved');
}

console.log('fetch available?', !!fetch)