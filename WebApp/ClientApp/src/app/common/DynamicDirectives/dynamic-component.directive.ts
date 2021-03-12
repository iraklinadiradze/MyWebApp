import { Directive, ViewContainerRef } from '@angular/core';

@Directive({
  selector: '[DynamicComponentHost]'
})
export class DynamicComponentDirective {
  constructor(public viewContainer: ViewContainerRef){}
}
