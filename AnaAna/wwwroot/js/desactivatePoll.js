httpRequest = new XMLHttpRequest();
let currentPollId; 

function makeRequest(pollId) {

    if (!httpRequest) {
        alert('Giving up :( Cannot create an XMLHTTP instance');
        return false;
    }

    httpRequest.open('GET', `https://localhost:5001/Polls/Desactivate?pollId=${pollId}`);
    httpRequest.onreadystatechange = alertContents;
    httpRequest.send();
}

function alertContents() {
    if (httpRequest.readyState === XMLHttpRequest.DONE) {
        if (httpRequest.status === 200) {
            if (document.getElementById(`btn-disable-poll-${currentPollId}`)) {
                document.getElementById(`btn-disable-poll-${currentPollId}`).disabled = true
            }
            if (document.getElementById("button-submit-poll")) {
                document.getElementById("button-submit-poll").disabled = true;
            }
            $('.toast').toast('show');

        }
    }

}

const desactivatePoll = (pollId) => {
    currentPollId = pollId
    makeRequest(pollId);
}
