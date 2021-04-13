import {
  Component, ComponentFactoryResolver, Type, ViewChild, ComponentRef, ViewRef, ViewContainerRef, Input,
  OnInit
} from '@angular/core';
// import { Router } from '@angular/router';

import { DynamicComponentService } from '../dynamic-component.service';
import { DynamicComponentDirective } from '../dynamic-component.directive';
import { IDynamicComponent } from '../dynamic-component.interface';

// import { User } from './components/security/user';
// import { SessionInfo } from './components/security/sessionInfo';

@Component({
    selector: 'app-container',
    templateUrl: './container.component.html',
    styleUrls: ['./container.component.scss']
})
/** Container component*/
export class ContainerComponent implements OnInit {
  @Input() public componentName: string;

  @ViewChild(DynamicComponentDirective, { static: true }) DynamicComponentHost: DynamicComponentDirective;

  constructor(
    private dynamicComponentService: DynamicComponentService,
    private componentFactoryResolver: ComponentFactoryResolver,
  ) {

  }

  ngOnInit(): void {
    this.loadComponent();
  }

  loadComponent() {
    console.log(this.componentName);
    var component = this.dynamicComponentService.getComponent(this.componentName);
    const componentFactory = this.componentFactoryResolver.resolveComponentFactory(component);

    const viewContainerRef = this.DynamicComponentHost.viewContainer;
    viewContainerRef.createComponent(componentFactory);

  }
}
