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

    if($this.is(':checked')){
        $('#video').removeAttr("disabled");
    } else {
        $('#video').attr("disabled", "disabled")
    }
})