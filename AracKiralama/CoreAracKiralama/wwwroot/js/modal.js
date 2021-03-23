$('#exampleModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget) // Button that triggered the modal
    var recipient = button.data('whatever')
    var name = button.data('nam')// Extract info from data-* attributes
    // If necessary, you could initiate an AJAX request here (and then do the updating in a callback).
    // Update the modal's content. We'll use jQuery here, but you could use a data binding library or other methods instead.
    var modal = $(this)
    modal.find('.modal-title').text('Emin misiniz ? ')
    modal.find('.modal-body span').text(recipient)
    modal.find('.modal-body input').val("Seçtiğiniz " + name + " silinecektir.")
    modal.find('.modal-footer a').attr("href", "Vehicle/Delete/" + recipient)
})