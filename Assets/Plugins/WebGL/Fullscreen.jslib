mergeInto(LibraryManager.library, {
    ToggleFullScreen: function () {
        var canvas = document.getElementById("unityContainer") || document.getElementById("unity-canvas") || document.querySelector("canvas");
        if (!canvas) {
            console.error("Canvas not found for fullscreen.");
            return;
        }

        if (!document.fullscreenElement) {
            canvas.requestFullscreen().catch(err => console.error("Failed to enter fullscreen:", err));
        } else {
            document.exitFullscreen();
        }
    }
});
