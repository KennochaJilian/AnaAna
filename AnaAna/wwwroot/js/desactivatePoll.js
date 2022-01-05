function makeRequest(pollId) {
    httpRequest = new XMLHttpRequest();

    if (!httpRequest) {
        alert('Giving up :( Cannot create an XMLHTTP instance');
        return false;
    }
    httpRequest.onreadystatechange = alertContents;
    httpRequest.open('GET', `https://localhost:5001/Polls/Desactivate?pollId=${pollId}`);
    httpRequest.send();
}

function alertContents() {
    if (httpRequest.readyState === XMLHttpRequest.DONE) {
        if (httpRequest.status === 200) {
            console.log("sondage desactivé")
        } else {
            console.log("probleme")
        }
    }
}

const desactivatePoll = () => {
    let pollId = document.getElementById("pollId").value;
    makeRequest(pollId); 
}
