//function sessionService(idService) {
//        $.ajax({
//         type: "POST",
//         data: { 'session-service': idService },
//         url: "/Elearning/sessionService",
//         success: function (retourServeur) {
//             $("#register_titreService").val(retourServeur);
//         }
        
//     });
//       $("#"+idService).attr("data-target", "#demandeService-register");
//}

function afficheModalServiceDescription(idService) {
    $.ajax({
        type: "POST",
        data: { 'session-service': idService },
        url: "/Elearning/afficheModalServiceDescription",
        success: function (retourServeur) {
            $("#descriptionService .modal-content").html(retourServeur);
        },
        error: function(jqXHR, textStatus, errorThrown){
            alert( errorThrown);
    }   
    });
}
function afficheModalServiceForm() {
    $.ajax({
        type: "POST",
        url: "/Elearning/afficheModalServiceForm",
        success: function (retourServeur) {
            $("#demandeService-register .modal-content").html(retourServeur);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function demandeService() {
    messageErreur = '';
    var today = new Date();
    var mydate = document.getElementById("register-dateUtilisation").value;
    var desiredDay = new Date(mydate);
    erreur = false;
   
    $('#demandeService .form-control').each(function () {
        if ($(this).val() != '') {
            erreur = false;
            messageErreur = '';
            $(this).removeClass('erreurSaisie');
        } else {
            erreur = true;
            $(this).addClass('erreurSaisie');
        }
    });
    if (desiredDay < today || mydate == "") {
        messageErreur += 'date incorrect.<br/>';
        $('#register-dateUtilisation').addClass('erreurSaisie');
    }
    if (erreur == true) {
        messageErreur += 'Champ obligatoire doit etre rempli.<br/>';
    }
    
    if (messageErreur == '') {
        $.ajax({
            type: "POST",
            data: {
                'register-dateUtilisation': $('#register-dateUtilisation').val(),
                'register-nbrUtilisateur': $('#register-nbrUtilisateur').val(),
                'register-periode': $('#register-periode').val(),
            },
            url: "/Elearning/demanderService",
            success: function (retourServeur) {
                $('html,body').scrollTop(0);
                $('body').html(retourServeur);
                $('.alert-success .alert-content p').html('La demande est envoyée avec succèes!');
                $('.alert-success').show();
                $('#demandeService .form-control').each(function () {
                    $(this).val('');
                });

            }
        });
    } else {
        $('.alert-error .alert-content p').html(messageErreur);
        //alerte(messageErreur);
        $('.alert-error').show();
    }
}
function afficheNotif() {
    $.ajax({
        type: "POST",
        url: "/Elearning/afficheNotification",
        success: function (retourServeur) {
            $("#notificationContainer .notifications").html(retourServeur);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function afficheListUser() {
    $.ajax({
        type: "POST",
        url: "/Elearning/afficheListUser",
        success: function (retourServeur) {
            $('body').html(retourServeur);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}
function afficheListAchat() {
    $.ajax({
        type: "POST",
        url: "/Elearning/afficheListAchat",
        success: function (retourServeur) {
            $('body').html(retourServeur);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert(errorThrown);
        }
    });
}

