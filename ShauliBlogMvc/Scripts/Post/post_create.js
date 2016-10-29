$('#addImageCheckbox').click(function () {
    var $this = $(this);

    if ($this.is(':checked')) {
        $('#image').removeAttr("disabled");
    } else {
        $('#image').attr("disabled", "disabled")
    }
});

$('#addVideoCheckbox').click(function () {
    var $this = $(this);

    if ($this.is(':checked')) {
        $('#video').removeAttr("disabled");
    } else {
        $('#video').attr("disabled", "disabled")
    }
});

$("document").ready(function () {

    window.fbAsyncInit = function () {
        FB.init({
            appId: '317961218577920',
            xfbml: true,
            version: 'v2.8'
        });
    };

    (function (d, s, id) {
        var js, fjs = d.getElementsByTagName(s)[0];
        if (d.getElementById(id)) { return; }
        js = d.createElement(s); js.id = id;
        js.src = "//connect.facebook.net/en_US/sdk.js";
        fjs.parentNode.insertBefore(js, fjs);
    }(document, 'script', 'facebook-jssdk'));


});

function postStatusToFacebook() {

    // get the the post text
    var element = document.getElementById("Content");
    var value = element.value;

    // show the facebook login pop up (if there is no a valid token)
    FB.login(function () {

        // get the page acess token
        FB.api('/349841955355640', 'get', { fields: "access_token" },
            function (response) {
                // then publish a post with the post text , and add the page access token
                FB.api('/349841955355640/feed', 'post', { message: value, access_token: response.access_token },
                        function (response) {
                            // log the response (will be the id of the post if succeeded
                            console.log(response);
                        });
                // log the access token request response.
                console.log(response);
            });
        // in order to ask for the page access token we add to the request the manage_pages permission
    }, { scope: 'manage_pages' });
}