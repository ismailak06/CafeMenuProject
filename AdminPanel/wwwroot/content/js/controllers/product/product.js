function DeleteProduct(productId) {
    var postData = { productId: productId };
    $.ajax({
        url: "product/delete",
        type: 'POST',
        data: postData,
        dataType: "json"
    });
}