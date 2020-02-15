$(function () {
    // a tagimizde bulunan update idmiz click olduğunda
    $("body").on("click", "#activeorpassive", function () {
        //data-target dan url mizi al
        var url = $(this).data("target");
        //bu urlimizi post et
        $.post(url, function (data) { })
            //eğer işlemimiz başarılı bir şekilde gerçekleşirse
            .done(function (data) {
                //gelen datayı .modal-body mizin içerise html olarak ekle
                $("#activeOrPassiveModel .modal-body").html(data);
                //sonra da modalimizi göster
                $("#activeOrPassiveModel").modal("show");
            })
            //eğer işlem başarısız olursa
            .fail(function () {
                //modalımızın bodysine Error! yaz
                $("#activeOrPassiveModel .modal-body").text("Error!!");
                //sonra da modalimizi göster
                $("#activeOrPassiveModel").modal("show");
            })

    });
})
