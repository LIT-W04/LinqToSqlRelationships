$(function() {
    $(".show").on('click', function() {
        var personId = $(this).data('person-id');
        $.post('/home/GetCars', {personId: personId}, function(result) {
            console.log(result);
        });
    });
}); 