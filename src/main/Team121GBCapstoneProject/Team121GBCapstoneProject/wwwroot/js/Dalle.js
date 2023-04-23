//import { onClick } from "./reCAPTCHAV3.js";

$(document).ready(() => {
	const baseUrl = $(location).attr("origin");
	$.ajax({
		method: "GET",
		url: `${baseUrl}/api/Dalle/UpdateCreditsForView`,
		contentType: "json",
		success: successGettingCreditCount,
		errorOnAjax: errorGettingCreditCount
	});
});

function successGettingCreditCount(data) {
	console.log('succeeded getting credit count');
	if (data === 0) {
		$('#creditsCounter').empty()
			.text(`Credits remaining: ${data} You've use all of your free credits.`);
		$('#userPrompt').prop('disabled', true);
		$('#submitPromptButton').prop('disabled', true);
		return;
	}
	$('#creditsCounter').empty()
		.text(`Credits remaining: ${data}`);

}

function errorGettingCreditCount(data) {
	console.log('failed getting credit count');
	//$('#creditsCounter').empty()
	//	.text(`Credits remaining: ${data}`);
}

function dalleModalOpen() {
	$('#DalleModal').modal('show');
}
function dalleModalClose() {
	$('#DalleModal').modal('hide');
}

function displayImage(data) {
	displayStatusToClient();
	console.log("Successfully made image with dalle: " + data);

	let temp = document.createElement("img");
	$("img").attr("id", "dalleImage");
	temp.src = `${data.responseText}`;
	temp.style.display = "block";
	temp.style.marginLeft = "auto";
	temp.style.marginRight = "auto";
	document.getElementById("applyProfilePhoto").removeAttribute("hidden");
	document.getElementById("imageHere").removeAttribute("hidden");

	document.getElementById("imageHere").innerHTML = "";
	//document.getElementById("imageHere").setAttribute("href", `${data.responseText}`)
	//document.getElementById("imageHere").setAttribute("download", "DalleGeneratedImage")
	document.getElementById("imageHere").appendChild(temp);
	document.getElementById("submitPromptButton").setAttribute("aria-disabled", "false");
	

	//document.getElementById("imageHere").removeAttribute("hidden");
	//document.getElementById("imageHere").setAttribute("src", `${data.responseText}`)

}

function displayStatusToClient() {
	const notification = `<div class="alert alert-success alert-dismissible" role="alert">
                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                            <h1>Successfully made image with DALL-E!</h1>
                          </div>`;
	$("#statusNotificationDiv").append(notification);
}

function errorOnAjax(data) {
	console.log("Error in AJAX call" + data.url);
}

$(function () {
	$("#promptForm").submit(function (event) {
		// prevent automatic submission of the form from button press or typing enter
		event.preventDefault();
	})

//	document.getElementById("submitPromptButton").setAttribute("aria-disabled", "true");

//	$("#submitPromptButton").click(function () {
//		const userPrompt = document.getElementById("userPrompt")
//		if (userPrompt.value != "") {
//			console.log(userPrompt);
//			$.ajax({
//				method: "GET",
//				url: `/api/Dalle/GetImages?prompt=${userPrompt.value}`,
//				dataType: "json",					// data type expected in response
//				success: displayImage,
//				error: displayImage
//			});
//		};
//	});
});

function dalleClick() {
	const userPrompt = document.getElementById("userPrompt")
	const recaptcha = $("#dalleRecaptcha").val();
	if (userPrompt.value != "") {
		console.log(userPrompt);
		console.log(recaptcha);
		$.ajax({
			method: "GET",
			url: `/api/Dalle/GetImages?prompt=${userPrompt.value}&gRecaptchaResponse=${recaptcha}`,
			dataType: "json",					// data type expected in response
			success: displayImage,
			error: displayImage
		});
	};
};