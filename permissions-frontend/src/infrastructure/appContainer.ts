export class AppContainer {
    private static toastComponent

    static setToastComponent(_toastComponent) {
        AppContainer.toastComponent = _toastComponent
    }

    static showToast(message: string) {
        AppContainer.toastComponent.show(message)
    }
}