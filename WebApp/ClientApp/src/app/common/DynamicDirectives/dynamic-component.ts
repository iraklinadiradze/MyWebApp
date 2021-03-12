import { Type } from '@angular/core';

export class DynamicComponent {
  constructor(path: string, public component: Type<any>) { }
}
