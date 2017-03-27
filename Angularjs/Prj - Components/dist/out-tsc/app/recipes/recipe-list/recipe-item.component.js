var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component, Input } from '@angular/core';
import { Recipe } from '../recipe';
export var RecipeItemComponent = (function () {
    function RecipeItemComponent() {
    }
    RecipeItemComponent.prototype.ngOnInit = function () {
    };
    __decorate([
        Input(), 
        __metadata('design:type', Recipe)
    ], RecipeItemComponent.prototype, "recipe", void 0);
    RecipeItemComponent = __decorate([
        Component({
            selector: 'rb-recipe-item',
            templateUrl: 'recipe-item.component.html'
        }), 
        __metadata('design:paramtypes', [])
    ], RecipeItemComponent);
    return RecipeItemComponent;
}());
//# sourceMappingURL=E:/Javascript/Angularjs/Prj - Components/src/app/recipes/recipe-list/recipe-item.component.js.map