class Tracker {
    constructor() { }

    postTrackerInfo() {
        return fetch(this.endpoint, {
            headers: {
                'Content-Type': 'application/json; charset=utf-8'
            },
            method: 'POST',
            body: this.createRequestBody()
        });
    }

    createRequestBody() {
        return JSON.stringify({
            Url: this.location,
            Browser: this.currentBrowser,
            Ip: this.visitorIp,
            PageParams: this.pageParams
        });
    }

    get currentBrowser() {
        var browserOptions = [
            "Vivaldi",
            "Trident",
            "Edge",
            "Chrome",
            "Firefox",
            "Safari",
            "Opera",
            "MSIE"
        ];
        var browser, userAgent = navigator.userAgent;
        for (var i = 0; i < browserOptions.length; i++) {
            if (userAgent.indexOf(browserOptions[i]) > -1) {
                browser = browserOptions[i];
                break;
            }
        }
        if (browser == "MSIE" || browser == "Trident" || browser == "Edge") {
            browser = "Internet Explorer";
        }

        return browser;
    }

    get visitorIp() {
        var xmlHttp = new XMLHttpRequest();
        xmlHttp.open("GET", "https://api.ipify.org/", false);
        xmlHttp.send(null);
        return xmlHttp.responseText;
    }

    get pageParams() {
        let currentUrl = new URL(window.location.href);
        return currentUrl.search
            .replace('?', '')
            .replace(/&/g, ', ')
            .replace(/=/g, ': ');
    }

    get location() {
        return window.location.href;
    }

    get endpoint() {
        return 'http://localhost:5000/api/visits';
    }
}

window.addEventListener('load', function () {
    let tracker = new Tracker();
    console.log(tracker.pageParams);
    console.log('ip: ' + tracker.visitorIp);
    tracker.postTrackerInfo()
        .then(function (response) {
            console.log(response);
        });
});
