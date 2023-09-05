javascript: (function () {
  var elementHref = document.evaluate(
    '/html/body/div[1]/span/div/div[1]/div/main/div[1]/div/div[3]/div[1]/div/div[3]/div[2]/div/div/div/div/div/div/div[1]/a',
    document,
    null,
    XPathResult.FIRST_ORDERED_NODE_TYPE,
    null
  ).singleNodeValue;
  var elementSrc = document.evaluate(
    '//*[@id="freezeBlock"]/div/div/main/div[1]/div/div[3]/div[1]/div/div[1]/div[1]/div/div[1]/div/div/a/div/div/div[1]/img',
    document,
    null,
    XPathResult.FIRST_ORDERED_NODE_TYPE,
    null
  ).singleNodeValue;
  var url = window.location.href;
  var lastSegment = url.substring(url.lastIndexOf("/") + 1);
  if (elementHref && elementSrc) {
    var linkHref = elementHref.getAttribute("href");
    var linkSrc = elementSrc.getAttribute("src");
    if (linkHref && linkSrc) {
      linkHref = "https://civitai.com" + linkHref;
      linkSrc = linkSrc;
      var finalText =
        '!curl -Lo "/content/microsoftexcel/models/Lora/' +
        lastSegment +
        ".safetensors\" '" +
        linkHref +
        "'\n";
      finalText +=
        '!curl -Lo "/content/microsoftexcel/models/Lora/' +
        lastSegment +
        ".jpeg\" '" +
        linkSrc +
        "'";
      var tempInput = document.createElement("textarea");
      tempInput.value = finalText;
      document.body.appendChild(tempInput);
      tempInput.select();
      document.execCommand("copy");
      document.body.removeChild(tempInput);
      alert(
        "Os comandos foram copiados para a %C3%A1rea de transfer%C3%AAncia."
      );
    } else {
      alert("Um dos elementos n%C3%A3o possui um atributo href ou src.");
    }
  } else {
    alert("Um dos elementos n%C3%A3o foi encontrado na p%C3%A1gina.");
  }
})();
