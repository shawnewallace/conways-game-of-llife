//
//  extensions.swift
//  CGol
//
//  Created by Shawn Wallace on 9/22/16.
//  Copyright © 2016 Shawn Wallace. All rights reserved.
//

import Foundation

extension Float {
  /// Rounds the double to decimal places value
  func roundTo(places:Int) -> Float {
    let divisor = pow(10.0, Float(places))
    return (self * divisor).rounded() / divisor
  }
}
